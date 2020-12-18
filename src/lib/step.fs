\ lib/for.fs

\ This file is part of Sin Forth.

\ This file adds `for` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012181748.
\ See change log at the end of the file.

\ ==============================================================

require backward-resolve.fs \ `<resolve`

get-order get-current

compiler-definitions

  \ Code adapted from Z88 CamelForth. Modified to do the check
  \ before decrementing the index.

: step \ Compilation: ( dest -- )
       \ Run-time:    ( R: u -- u' )

  \ doc{
  \
  \ step
  \   Compilation: ( dest -- )
  \   Run-time:    ( R: u -- u' )

  \ End a ``for``..`step` loop.
  \
  \ Compilation: Compile the run-time semantics described below,
  \ resolving the destination address _dest_, which was left by `for`.
  \
  \ Run-time: If the loop index _u_ is zero, discard it and continue
  \ execution after the loop. Otherwise decrement the loop index and
  \ continue execution at the beginning of the loop.
  \
  \ }doc

  compiler{
  h pop,         \ pop hl
  h a ld,        \ ld a,h
  l or,          \ or l ; z=already zero?
  h decp,        \ dec hl
  h push,        \ push hl
  $0000 nz? ?jp, \ jp nz, dest ; jump to loop
  <resolve       \ resolve _dest_ in the previous `?jp,`
  h pop,         \ pop hl ; discard loop index
  }
  ;

  \ doc{
  \
  \ step
  \   Compilation: ( dest -- )
  \   Run-time:    ( R: n -- n' )
  \
  \ Compilation: ( dest -- )
  \
  \ Append the run-time semantics given below to the current
  \ definition. Resolve the destination address _dest_, which
  \ was left by `for`.
  \
  \ Run-time: ( R: n -- n' )
  \
  \ If the loop index is zero, discard the loop parameters and
  \ continue execution after the loop. Otherwise decrement the
  \ loop index and continue execution at the beginning of the
  \ loop.
  \
  \ ``step`` is an `immediate` and `compile-only` word.
  \
  \ NOTE: ``step`` is usually called ``next`` in other Forth
  \ systems.
  \
  \ Origin: Z88 CamelForth.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-16: Start. Copy the code from Solo Forth 0.14.0-pre.124.
\
\ 2020-12-18: Add requirement of `<resolve`. Improve documentation.
