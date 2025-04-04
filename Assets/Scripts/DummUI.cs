
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class DummUI : MonoBehaviour
{
    [Header("�������� ���������")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float armor = 50f;
    [SerializeField] private int ammoCurrent = 30;
    [SerializeField] private int ammoTotal = 120;

    [Header("HUD ��������")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider armorSlider;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private RawImage minimapTexture;
    [SerializeField] private GameObject damageVignette;

    [Header("���� �����")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [Header("��������� ������")]
    [SerializeField] private Sprite[] weaponSprites;
    private int currentWeaponIndex = 0;

    private bool isPaused = false;
    private Camera minimapCamera;

    void Start()
    {
        // ������������� ���� ������ ����������
        if (healthSlider == null) healthSlider = transform.Find("HealthBar").GetComponent<Slider>();
        if (armorSlider == null) armorSlider = transform.Find("ArmorBar").GetComponent<Slider>();
        if (ammoText == null) ammoText = transform.Find("AmmoText").GetComponent<TMP_Text>();
        
        // ��������� ����-�����
        SetupMinimap();
        
        // ������������� UI
        UpdateHealthUI();
        UpdateArmorUI();
        UpdateAmmoUI();
        UpdateWeaponUI();

        // ��������� ������
        continueButton.onClick.AddListener(TogglePause);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
        
        // ������ ���� ��� ������
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // ��������� ����� �� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // �������� ������� (����� �������)
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(10f);
        if (Input.GetKeyDown(KeyCode.A)) AddAmmo(10);
        if (Input.GetKeyDown(KeyCode.W)) SwitchWeapon();
    }

    #region �������� ������ UI
    public void TakeDamage(float damage)
    {
        if (armor > 0)
        {
            armor -= damage;
            if (armor < 0)
            {
                health += armor; // ������� ����� ����� �����
                armor = 0;
            }
        }
        else
        {
            health -= damage;
        }

        health = Mathf.Clamp(health, 0, 100);
        armor = Mathf.Clamp(armor, 0, 50);

        UpdateHealthUI();
        UpdateArmorUI();
        StartCoroutine(ShowDamageEffect());
    }

    public void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
        UpdateHealthUI();
    }

    public void AddArmor(float amount)
    {
        armor = Mathf.Clamp(armor + amount, 0, 50);
        UpdateArmorUI();
    }

    public void AddAmmo(int amount)
    {
        ammoCurrent += amount;
        UpdateAmmoUI();
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponSprites.Length;
        UpdateWeaponUI();
    }
    #endregion

    #region ���������� UI ���������
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
            healthSlider.value = health / 100f;
    }

    private void UpdateArmorUI()
    {
        if (armorSlider != null)
            armorSlider.value = armor / 50f;
    }

    private void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = $"{ammoCurrent}/{ammoTotal}";
    }

    private void UpdateWeaponUI()
    {
        if (weaponIcon != null && weaponSprites.Length > 0)
            weaponIcon.sprite = weaponSprites[currentWeaponIndex];
    }
    #endregion

    #region ���������
    private void SetupMinimap()
    {
        if (minimapTexture != null)
        {
            // ������� ������ ��� ����-�����
            GameObject minimapCamObj = new GameObject("MinimapCamera");
            minimapCamera = minimapCamObj.AddComponent<Camera>();
        
            // ��������� ������
            minimapCamera.orthographic = true;
            minimapCamera.orthographicSize = 20f;
            minimapCamera.cullingMask = LayerMask.GetMask("Minimap");
            minimapCamera.transform.position = new Vector3(0, 50f, 0);
            minimapCamera.transform.rotation = Quaternion.Euler(90f, 0, 0); // ���� minimimapCamera (������)
            minimapCamera.targetTexture = new RenderTexture(256, 256, 16);
        
            // �������� �������� � UI
            minimapTexture.texture = minimapCamera.targetTexture;
        }
    }
    #endregion

    #region ���� �����
    private void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void OpenSettings()
    {
        // ����� ����� �������� ������ ��������
        Debug.Log("Settings opened");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion

    #region �������
    private IEnumerator ShowDamageEffect()
    {
        if (damageVignette != null)
        {
            damageVignette.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            damageVignette.SetActive(false);
        }
    }
    #endregion
}
