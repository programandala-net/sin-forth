\ lib/pad.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require here.fs       \ `here`
require plus.fs       \ `+`
require slash-hold.fs \ `/hold`

: pad ( -- ca )
  here /hold + ;

  \ doc{
  \
  \ pad ( -- ca )
  \
  \ _ca_ is the address of a transient region that can be used to
  \ hold data for intermediate processing. It's a fixed offset
  \ (`/hold` bytes) above `here`.
  \
  \ ``pad`` is  specifically intended as  a programmer
  \ convenience. No standard words use it.
  \
  \ See also: `/pad`.
  \
  \ }doc
