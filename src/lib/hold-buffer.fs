\ lib/hold-buffer.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1320+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require buffer-colon.fs \ `buffer:`

compiler{ /hold-buffer } buffer: hold-buffer ( -- ca )

  \ doc{
  \
  \ hold-buffer ( -- ca )
  \
  \ _ca_ is the address of the pictured output string buffer. Its size
  \ is `/hold-buffer`.
  \
  \ See also: `<#`, `#`, `#s`, `hold`, `sign`, `#>`, `pad`.
  \
  \ }doc
